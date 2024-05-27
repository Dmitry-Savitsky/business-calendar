import { $authHost } from ".";
import {jwtDecode} from 'jwt-decode';

const getTokenData = () => {
    const token = localStorage.getItem('token');
    if (token) {
        const decodedToken = jwtDecode(token);
        return decodedToken;
    }
    return null;
};

const tokenData = getTokenData();

export const fetchOrders = async () => {
    try {
        const idCompany = tokenData["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
        console.log("idCompany:" + idCompany);
        const response = await $authHost.get(`api/orders/${idCompany}`);
        return response.data;
    } catch (error) {
        console.error('Fetch Orders error:', error);
        throw error;
    }
};

export const fetchOrder = async (idOrder) => {
    try {
        const idCompany = tokenData["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
        const response = await $authHost.get(`api/orders/${idCompany}/${idOrder}`);
        return response.data;
    } catch (error) {
        console.error('Fetch Order error:', error);
        throw error;
    }
};

export const createOrder = async (orderData) => {
    try {
        const idCompany = tokenData["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
        console.log("Creating order with idCompany:", idCompany); // Добавим отладочное сообщение
        const response = await $authHost.post('api/orders', { ...orderData, idCompany: idCompany, Confirmed: false, Completed: false });
        return response.data;
    } catch (error) {
        console.error('Create Order error:', error);
        throw error;
    }
};

export const updateOrder = async (idOrder, orderData) => {
    try {
        const idCompany = tokenData["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
        const response = await $authHost.put(`api/orders/${idCompany}/${idOrder}`, orderData);
        return response.data;
    } catch (error) {
        console.error('Update Order error:', error);
        throw error;
    }
};

export const deleteOrder = async (idOrder) => {
    try {
        const idCompany = tokenData["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
        const response = await $authHost.delete(`api/orders/${idCompany}/${idOrder}`);
        return response.data;
    } catch (error) {
        console.error('Delete Order error:', error);
        throw error;
    }
};