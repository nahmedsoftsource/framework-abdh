/// <reference path="~/Content/js/jquery-1.3.1.min-vsdoc.js" />

/**
* Core js file
*/
function Core() {
    $.ajaxSetup(
  {
      data: { 'X-Requested-With': 'XMLHttpRequest' },
      error: Core.errorHandler
  });

    $(document).ajaxError(function(event, xhr, settings) {
        try {
            if ($.trim(xhr.responseText).length > 0) {
                var exception = {};
                eval("exception = " + xhr.responseText);
                alert(exception.message);
            }
        }
        catch (e) {
            Core.log(e);
            alert("Sorry, an error occurred while processing your request.");
        }
    });
}

/******************************************************************************
* Base URL
******************************************************************************/
Core.prototype.baseURL = "/";

/******************************************************************************
* logging
******************************************************************************/

Core.prototype.log = function(obj) {
    if (typeof (console) != 'undefined') {
        if (typeof (console.log) == 'function') {
            console.log(obj);
        }
    }
}

/******************************************************************************
* Datepicker
******************************************************************************/
Core.prototype.datePicker = function(selector) {
    $("<a class='tool-icon-button' href='javascript:void(0)'><span class='tool-icon tool-icon-date-picker'>select date</span></a>").insertAfter(selector);
    $(selector).next().click(function() {
        showCalendar($(this).prev().get(0));
        return false;
    });
}

Core.prototype.reloadDatePicker = function() {
    $(".datepicker").datepicker({
        showOn: 'both',
        buttonImage: this.baseURL + 'Content/images/calendar.gif',
        buttonImageOnly: true,
        changeMonth: true,
        changeYear: true,
        showAnim: 'slide'
    });
}

Core.prototype.buildSelectList = function(id, data) {
    var options = '';
    for (var key in data) {
        options += '<option value="' + key + '">' + data[key] + '</option>';
    }
    jQuery(id).html(options);
}

Core.prototype.BuildSelectBox = function(id, data) {
    var options = '';
    for (var key in data) {
        options += '<option value="' + data[key].value + '">' + data[key].text + '</option>';
    }
    jQuery("#" + id).html(options);
}

Core.prototype.makeTooltips = function(triggerSelector, dropdownSelector) {
    var trigger = $(triggerSelector);
    var dropdown = $(dropdownSelector);
    trigger.hover(function() {
        dropdown.css("position", "absolute")
        .css("top", trigger.offset().top + trigger.height() + "px")
        .css("left", trigger.offset().left + "px")
        .show()
    }, function() {
        dropdown.hide();
    });
}

/******************************************************************************
* open dialog
******************************************************************************/
Core.prototype.defaultDialogOptions = {
    isPopup: false,
    title: 'Form',
    width: "600px",
    height: "auto",
    remoteOptions: { method: 'GET', isForm: false }
}

Core.prototype.openDialog = function(context) {
    var prev = Core.dialog;
    var options = $.extend(true, {}, Core.defaultDialogOptions);
    if (typeof (context) == 'string') {
        options = $.extend(true, options, { remoteOptions: { url: context} });
    }
    else {
        options = $.extend(true, options, context);
        if (!options.remoteOptions.data) {
            options.remoteOptions.data = {};
        }
        if (options.reloadId) {
            options.remoteOptions.data.ReloadID = options.reloadId;
        }
        if (options.reloadUrl) {
            options.remoteOptions.data.ReloadURL = options.reloadUrl;
        }
        if (options.afterClose) {
            options.remoteOptions.data.RunJS = options.runJs;
        }
    }
    var popupHolder;
    if (options.isPopup) {
        options = $.extend(true, { id: "_blank" }, options);
        var windowInstance = window.open(options.remoteOptions.url, options.id, "width=" + options.width + ",height=" + options.height + ",location=1");
        if (windowInstance != null) {
            popupHolder = $('<div style="display:none"></div>').appendTo('body');
            popupHolder.bind('close', function() { popupHolder.remove(); });
            $(windowInstance).unload(function() { popupHolder.trigger('close', [options]); });

            options.parentWindow = popupHolder;
            windowInstance.dialogOptions = options;
        }
    }
    else {
        Core.dialog = {
            _previous: prev
    , options: options
    , _dialog: Core.createDialog(options)
    , closeBox: function(eventName) {
        if (eventName) {
            this._dialog.trigger(eventName, [this.options]);
        }
        this._dialog.dialog('close');

        Core.dialog = this._previous;
        if (Core.dialog != undefined) {
            Core.dialog._dialog.dialog('moveToTop');
        }
    }
    , loadHtml: function(html) {
        this._dialog.html(html);
        this._dialog.dialog('option', 'position', 'center');
    }
        };
        // make it compatible with current floatbox
        Core.floatBox = Core.dialog;
        popupHolder = Core.dialog._dialog;
    }
    if (popupHolder != null) {
        if (options.bindEvents) {
            for (var event in options.bindEvents) {
                if (typeof (options.bindEvents[event]) == 'string'
          || typeof (options.bindEvents[event]) == 'function') {
                    popupHolder.bind(event, options.bindEvents[event]);
                }
            }
        }
        if (options.afterClose) {
            popupHolder.bind('close', options.afterClose);
        }
    }
}

/******************************************************************************
* open dialog
******************************************************************************/
Core.prototype.createDialog = function(options) {
    if (options.beforeOpen != undefined) {
        options.beforeOpen();
    }
    var dlg = $('<div style="display:none"><span class="loading-text"> Loading...</span></div>').appendTo('body');
    dlg.dialog({
        draggable: false,
        modal: true,
        resizable: false,
        title: options.title,
        beforeClose: options.beforeClose,
        method: 'GET',
        width: 600,
        height: 'auto',
        open: function() {
            Core.SubmitToRemote('', options.remoteOptions, function(html) {
                dlg.html(html);
                dlg.dialog('option', 'position', 'center');
            });
        },
        close: function() {
            $(this).dialog('destroy');
            $(this).trigger('close', [options]);
            $(this).remove();
        }
    });
    return dlg;
}
/******************************************************************************
* callback
******************************************************************************/
Core.prototype.Callback = function(data) {
    if (data[0] == "{") {
        eval("info = " + data);
        if (info.message) {
            alert(info.message);
        }
        if (info.update) {
            $("#" + info.update.id).load(info.update.url);
        }
    }
    else {
        Core.dialog.loadHtml(data);
    }
}

/******************************************************************************
* callback for dialog
******************************************************************************/
Core.prototype.DialogCallback = function(data) {
    data = data.toString();
    if (data.charAt(0) == "{") {
        eval("info = " + data);
        if (info.message) {
            alert(info.message);
        }
        var curDialog = Core.dialog;
        if (info.complete) {
            if (window.dialogOptions) {
                var dialogOptions = window.dialogOptions;
                if (info.eventName) {
                    dialogOptions.parentWindow.trigger(info.eventName, [dialogOptions]);
                }
                dialogOptions.parentWindow.trigger('close', [dialogOptions]);
                window.close();
                return;
            }
            else if (curDialog) {
                curDialog.closeBox(info.eventName);
            }
        }

        if (info.runJS)
            eval(info.runJS);


        if (info.reloadID && info.reloadURL) {
            $("#" + info.reloadID).load(info.reloadURL);
        }
        else if (curDialog && curDialog.options.reloadId && curDialog.options.reloadUrl) {
            $("#" + curDialog.options.reloadId).load(curDialog.options.reloadUrl);
        }

        if (info.redirectURL) {
            window.location = info.redirectURL;
        }
        else if (curDialog && curDialog.options.redirectURL) {
            window.location = curDialog.options.redirectURL;
        }
    } else {
        Core.dialog.loadHtml(data);
    }
}
/******************************************************************************
* SubmitToRemote
******************************************************************************/
Core.prototype.SubmitToRemote = function(button, options, onSuccessCallback) {
    var params = {};
    if (options.isForm) {
        if (options.causesValidation) {
            if (!$(button).parents('form').valid()) {
                return false;
            }
        }
        var formArray = $(button).parents('form').serializeArray();
        for (var i in formArray) {
            if (formArray[i]) {
                if ($.isArray(params[formArray[i].name])) {
                    params[formArray[i].name][params[formArray[i].name].length] = formArray[i].value;
                }
                else {
                    params[formArray[i].name] = [formArray[i].value];
                }
            }
        }
    }

    if (options.data) {
        $.extend(true, params, options.data);
    }

    if (options["with"]) {
        for (var i in options["with"]) {
            if (typeof (options["with"][i]) == 'string') {
                params[options["with"][i]] = $("#" + options["with"][i]).val();
            }
        }
    }

    $.ajax({
        url: options.url,
        type: options.method,
        data: params,
        success: function(data, textStatus) {
            if (options.update) {
                $("#" + options.update).html(data);
            }
            if (typeof (onSuccessCallback) == 'function') {
                onSuccessCallback(data, textStatus);
            }
            else if (typeof (onSuccessCallback) == 'string') {
                eval(onSuccessCallback);
            }
        }
    });
}

/******************************************************************************
* Panel
******************************************************************************/
Core.prototype.CreatePanel = function(selector, options) {
    $(selector).refreshPanel = function() {
        Core.SubmitToRemote(options.RemoteOptions);
    }
}

Core.prototype.RefreshPanel = function(selector) {
    $(selector).refreshPanel(params);
}

/******************************************************************************
* Tabs
******************************************************************************/
Core.prototype.Tabs = function(selector) {
    $(selector + ' li[class="x-tab-strip"], ' + selector + ' li[class="x-tab-strip-active"]').click(function() {
        // if current tabitem is active, do nothing
        if ($(this).hasClass("x-tab-strip-active")) {
            return;
        }

        tabItemId = $(this).attr("id");
        tabId = Core.getParentId(tabItemId);
        tabItemContentId = tabItemId + "_TabContent";

        // active tab item | x-tab-strip-active
        $("li[id^=" + tabId + "]").removeClass("x-tab-strip-active").addClass("x-tab-strip");
        $("#" + tabItemId).removeClass("x-tab-strip").addClass("x-tab-strip-active");

        // hide all tab content of tabId
        $("[id^=" + tabId + "][id$=_TabContent]").removeClass("x-tab-panel-active").addClass("x-tab-panel-inactive");
        $("#" + tabItemContentId).removeClass("x-tab-panel-inactive").addClass("x-tab-panel-active");

    });
}
Core.prototype.getParentId = function(id) {
    return id.substr(0, id.lastIndexOf("_"));
}


/******************************************************************************
* Object Container
* contain object and set/get by key
******************************************************************************/
function ObjectContainer() {
    this.data = {};
}

ObjectContainer.prototype.set = function(key, obj) {
    //	eval("this.data." + key + " = obj");
    this.data[key] = obj;
}

ObjectContainer.prototype.get = function(key) {
    //	eval("obj = this.data." + key);
    return this.data[key];
}

ObjectContainer.prototype.keyStartWith = function(key) {
    var ret = [];
    for (var i in this.data) {
        if (i.substring(key.length, 0) == key) {
            ret[ret.length] = this.data[i];
        }
    }

    return ret;
}

ObjectContainer.prototype.remove = function(key) {
    delete this.data[key];
}

ObjectContainer.prototype.removeStartWith = function(key) {
    var ret = [];
    for (var i in this.data) {
        if (i.substring(key.length, 0) == key) {
            delete this.data[i];
        }
    }

    return ret;
}

ObjectContainer.prototype.clean = function() {
    this.data = {};
}

/******************************************************************************
* JSON
******************************************************************************/
Core.prototype.JSON = {
    encode: function(obj) {
        return YAHOO.lang.JSON.stringify(obj);
    },
    decode: function() {
    }
}

/******************************************************************************
* format suggest item
******************************************************************************/
Core.prototype.formatSuggestItem = function(row) {
    eval("var info = " + row[0]);
    return info.html;
}

Core.prototype.formatSuggestResult = function(row) {
    eval("var info = " + row[0]);
    return info.text;
}

/******************************************************************************
* Array method
******************************************************************************/
Core.prototype.removeElementFromArray = function(arr, from, to) {
    var rest = arr.slice((to || from) + 1 || arr.length);
    arr.length = from < 0 ? arr.length + from : from;
    return arr.push.apply(arr, rest);
};

/******************************************************************************
* Core object
******************************************************************************/
var Core = new Core();
Core.objectContainer = new ObjectContainer();

