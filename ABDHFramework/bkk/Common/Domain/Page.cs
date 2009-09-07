using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class Page : Superior.MobileMedics.Common.DomainBase<Guid>
  {
    private int _rowCount;
    private int _pageCount;
    private int _pageSize;
    private int _currentPage;

    public int RowCount
    {
      get
      {
        return _rowCount;
      }
      set
      {
        if (value < 1)
        {
          _rowCount = 1;
          _pageCount = 1;
        }
        else
        {
          _rowCount = value;
          _pageCount = _rowCount / _pageSize + 1;
        }
      }
    }

    public int PageCount
    {
      get
      {
        return _pageCount;
      }
    }

    public int CurrentPage
    {
      get
      {
        return _currentPage;
      }
      set
      {
        if (value < 1) 
        {
          _currentPage = 1;
        }
        else if (value > _pageCount)
        {
          _currentPage = _pageCount;
        }
        else
        {
          _currentPage = value;
        }
      }
    }

    public int PageSize
    {
      get
      {
        return _pageSize;
      }
      set
      {
        _pageSize = value;
      }
    }

    public Page(int currentPage)
    {
      CurrentPage = currentPage;
      PageSize = 10;
      RowCount = 0;
    }

    public Page(int rowCount, int pageSize)
    {
      PageSize = pageSize;
      RowCount = rowCount;
      CurrentPage = 1;
    }

    public int Previous()
    {
      if (_currentPage > 1)
      {
        _currentPage--;
      }
      else
      {
        _currentPage = 1;
      }
      return _currentPage;
    }

    public int Next()
    {
      if (_currentPage < _pageCount)
      {
        _currentPage++;
      }
      else
      {
        _currentPage = _pageCount;
      }
      return _currentPage;
    }
    
  }
}
