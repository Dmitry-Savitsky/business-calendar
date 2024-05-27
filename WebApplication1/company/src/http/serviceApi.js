import { $authHost } from ".";
import { jwtDecode } from 'jwt-decode';

const getTokenData = () => {
    const token = localStorage.getItem('token');
    if (token) {
        const decodedToken = jwtDecode(token);
        return decodedToken;
    }
    return null;
};

const tokenData = getTokenData();

export const fetchServices = async () => {
    try {
        const idCompany = tokenData["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
        console.log("idCompany:" + idCompany);
        const response = await $authHost.get(`api/services/${idCompany}`);
        return response.data;
    } catch (error) {
        console.error('Fetch Services error:', error);
        throw error;
    }
};

export const createService = async (serviceData) => {
    try {
        const idCompany = tokenData["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
        console.log("Creating service with idCompany:", idCompany); // Добавим отладочное сообщение
        const response = await $authHost.post('api/services', { ...serviceData, idCompany: idCompany });
        return response.data;
    } catch (error) {
        console.error('Create Service error:', error);
        throw error;
    }
};

export const deleteService = async (idService) => {
    try {
        const response = await $authHost.delete(`api/services/${idService}`);
        return response.data;
    } catch (error) {
        console.error('Delete Service error:', error);
        throw error;
    }
};