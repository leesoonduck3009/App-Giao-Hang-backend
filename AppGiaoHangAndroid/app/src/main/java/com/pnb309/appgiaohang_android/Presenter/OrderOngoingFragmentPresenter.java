package com.pnb309.appgiaohang_android.Presenter;

import com.pnb309.appgiaohang_android.Contract.IOrderOngoingFragmentContract;
import com.pnb309.appgiaohang_android.Entity.CustomerOrder;
import com.pnb309.appgiaohang_android.Model.CustomerOrderModel;
import com.pnb309.appgiaohang_android.Model.ICustomerOrderModel;

import java.util.ArrayList;

public class OrderOngoingFragmentPresenter implements IOrderOngoingFragmentContract.Presenter {
    private IOrderOngoingFragmentContract.View view;
    private ICustomerOrderModel model;
    public OrderOngoingFragmentPresenter(IOrderOngoingFragmentContract.View view)
    {
        this.view = view;
        model = new CustomerOrderModel();
    }
    @Override
    public void OnLoadingOrderCustomer(long employeeID) {
        model.LoadCustomerOrderByEmployeeIDAndStatus(employeeID, CustomerOrder.ORDER_ONGOING, customerOrderList -> {
            if(customerOrderList == null)
                customerOrderList = new ArrayList<>();
            view.LoadOrderCustomer(customerOrderList);
        });
    }
}