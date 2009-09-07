using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Superior.MobileMedics.Common.DataAccess.NHibernateClient;
using Superior.MobileMedics.Domain.EmployeeManagement;
using Superior.MobileMedics.DataAccess.EmployeeManagement;
using Superior.Data;
using Superior.MobileMedics.Common.Domain;
using NHibernate.Expression;

namespace Superior.MobileMedics.DataAccess.EmployeeManagement.NHibernateClient
{
  public class EmployeeDA:BaseDA<Guid,Employee>,IEmployeeDA
  {
    protected override void BeforeSearch(Superior.Data.ISearchQuery query)
    {
      base.BeforeSearch(query);
      if (!query.Expressions.ContainsKey("Person.DeletedDate"))
      {
        query.Where("Person.DeletedDate").IsNull();
      }
    }

    public SearchResult<Employee> SearchEmpByOrderInfo(DateTime? fromOrderDate,
      DateTime? toOrderDate,List<Object> listOfStatusID,
      uint searchBy, Guid? departmentID, int currPage
      )
    {
      ISearchQuery query = SearchQueryBuilder.CreateQuery();

      SearchEmpByOrderInfoCriteria searchEmpCriteria = new SearchEmpByOrderInfoCriteria();
      if (fromOrderDate != null && fromOrderDate.HasValue 
        && fromOrderDate.Value > System.Data.SqlTypes.SqlDateTime.MinValue.Value
        && fromOrderDate.Value < System.Data.SqlTypes.SqlDateTime.MaxValue.Value)
      {
        searchEmpCriteria.FromOrderDate = fromOrderDate.Value;
      }

      if (toOrderDate != null && toOrderDate.HasValue
           && toOrderDate.Value > System.Data.SqlTypes.SqlDateTime.MinValue.Value
          && toOrderDate.Value < System.Data.SqlTypes.SqlDateTime.MaxValue.Value)

      {
        searchEmpCriteria.ToOrderDate = toOrderDate.Value;
      }
      
      searchEmpCriteria.ListOfOrderStatus= listOfStatusID;

      searchEmpCriteria.SearchBy = searchBy;
      if (departmentID != null && departmentID.HasValue && departmentID.Value!=Guid.Empty)
      {
        searchEmpCriteria.DepartmentID = departmentID.Value;
      }
      query.SetCriteria(searchEmpCriteria);
      
      if (currPage != 0)
      {
        query.SetPage(currPage);
        query.SetMaxResults(ConfigurationSettings.DefaultPageSize);
      }
      return Search(query);
    }

    public SearchResult<Employee> SearchEmpByOrderInfo(DateTime? fromOrderDate,
  DateTime? toOrderDate, int orderStatusID,
  uint searchBy, Guid? departmentID, int currPage
  )
    {
      ISearchQuery query = SearchQueryBuilder.CreateQuery();

      SearchEmpByOrderInfoCriteria searchEmpCriteria = new SearchEmpByOrderInfoCriteria();
      if (fromOrderDate != null && fromOrderDate.HasValue
        && fromOrderDate.Value > System.Data.SqlTypes.SqlDateTime.MinValue.Value
        && fromOrderDate.Value < System.Data.SqlTypes.SqlDateTime.MaxValue.Value)
      {
        searchEmpCriteria.FromOrderDate = fromOrderDate.Value;
      }

      if (toOrderDate != null && toOrderDate.HasValue
           && toOrderDate.Value > System.Data.SqlTypes.SqlDateTime.MinValue.Value
          && toOrderDate.Value < System.Data.SqlTypes.SqlDateTime.MaxValue.Value)
      {
        searchEmpCriteria.ToOrderDate = toOrderDate.Value;
      }

      searchEmpCriteria.OrderStatus = orderStatusID;

      searchEmpCriteria.SearchBy = searchBy;
      if (departmentID != null && departmentID.HasValue && departmentID.Value != Guid.Empty)
      {
        searchEmpCriteria.DepartmentID = departmentID.Value;
      }
      query.SetCriteria(searchEmpCriteria);

      if (currPage != 0)
      {
        query.SetPage(currPage);
        query.SetMaxResults(ConfigurationSettings.DefaultPageSize);
      }
      return Search(query);
    }

    protected override NHibernate.ICriteria ParseCriteria<Y>(SearchCriteria searchCriteria)
    {
      NHibernate.ICriteria criteria = base.ParseCriteria<Y>(searchCriteria);
      SearchEmpByOrderInfoCriteria searchEmpByOrderCriteria = searchCriteria as SearchEmpByOrderInfoCriteria;
      if (searchEmpByOrderCriteria != null)
      {

        //criteria.CreateAlias("[Order]", "o", NHibernate.SqlCommand.JoinType.LeftOuterJoin);
        StringBuilder sb = new StringBuilder();
        if (searchEmpByOrderCriteria.SearchBy == SearchEmpByOrderInfoCriteria.SEARCH_BY_CASE_MANAGER)
        {
          sb.Append(" {alias}.ID IN (Select o.CaseManagerID from [Order] o");
          sb.Append(" WHERE o.CaseManagerID IS NOT NULL  ");
        }
        else
        {
          sb.Append(" {alias}.ID IN (Select o.OrderTakerID from [Order] o");
          sb.Append(" WHERE o.OrderTakerID IS NOT NULL ");
        }
        if (searchEmpByOrderCriteria.FromOrderDate != null
          && searchEmpByOrderCriteria.FromOrderDate > System.Data.SqlTypes.SqlDateTime.MinValue.Value
          && searchEmpByOrderCriteria.FromOrderDate < System.Data.SqlTypes.SqlDateTime.MaxValue.Value)
        {
          sb.Append(" and o.CreatedDate > '" + searchEmpByOrderCriteria.FromOrderDate.ToShortDateString()+ " " +  searchEmpByOrderCriteria.FromOrderDate.ToShortTimeString()+ "'");
        }
        if (searchEmpByOrderCriteria.ToOrderDate != null
          && searchEmpByOrderCriteria.ToOrderDate > System.Data.SqlTypes.SqlDateTime.MinValue.Value
          && searchEmpByOrderCriteria.ToOrderDate < System.Data.SqlTypes.SqlDateTime.MaxValue.Value)
        {
          sb.Append(" and o.CreatedDate < '" + searchEmpByOrderCriteria.ToOrderDate.ToShortDateString() + " " +  searchEmpByOrderCriteria.ToOrderDate.ToShortTimeString()+ "'");
        }
        if (searchEmpByOrderCriteria.OrderStatus != 0)
          sb.Append((" and o.OrderStatusID="+ searchEmpByOrderCriteria.OrderStatus.ToString()));
        else if ((searchEmpByOrderCriteria.ListOfOrderStatus != null) && (searchEmpByOrderCriteria.ListOfOrderStatus.Count > 0))
        {
          String s = "";
          foreach (Object o in searchEmpByOrderCriteria.ListOfOrderStatus)
          {
            if (!String.IsNullOrEmpty(s))
            {
              s += ",";
            }
            s += o.ToString();
          }
          s = "(" + s + ")";
          sb.Append((" and o.OrderStatusID in " + s));
        }
        sb.Append(")");
        criteria.Add(Expression.Sql(sb.ToString()));

        //if (searchEmpByOrderCriteria.SearchBy == SearchEmpByOrderInfoCriteria.SEARCH_BY_CASE_MANAGER)
        //{
        //  criteria.CreateAlias("EmployeeTitle", "empTitle", NHibernate.SqlCommand.JoinType.LeftOuterJoin);
        //}
        //if (searchEmpByOrderCriteria.SearchBy == SearchEmpByOrderInfoCriteria.SEARCH_BY_ORDER_REP)
        //{
        //  criteria.CreateAlias("Department", "dept", NHibernate.SqlCommand.JoinType.LeftOuterJoin);
        //}

        criteria.Add(Expression.Sql(sb.ToString()));

        if (searchEmpByOrderCriteria.SearchBy == SearchEmpByOrderInfoCriteria.SEARCH_BY_CASE_MANAGER)
        {
          criteria.Add(Expression.Eq("EmployeeTitle.ID", EmployeeTitle.EMPLOYEE_TITLE.Case_Manager));
        }

        if (searchEmpByOrderCriteria.SearchBy == SearchEmpByOrderInfoCriteria.SEARCH_BY_ORDER_REP)
        {
          if (searchEmpByOrderCriteria.DepartmentID != Guid.Empty)
            criteria.Add(Expression.Eq("Department.ID", searchEmpByOrderCriteria.DepartmentID));
        }
      }

      return criteria;
    }
  }
}
