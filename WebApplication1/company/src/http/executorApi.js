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

export const fetchExecutors = async () => {
    try {
        const idCompany = tokenData["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
        console.log("idCompany:" + idCompany);
        const response = await $authHost.get(`api/executors/${idCompany}`);
        return response.data;
    } catch (error) {
        console.error('Fetch Executors error:', error);
        throw error;
    }
};

export const createExecutor = async (executorData) => {
    try {
        const idCompany = tokenData["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
        console.log("Creating executor with idCompany:", idCompany); // Добавим отладочное сообщение
        const response = await $authHost.post('api/executors', { ...executorData, idCompany: idCompany });
        return response.data;
    } catch (error) {
        console.error('Create Executor error:', error);
        throw error;
    }
};

export const deleteExecutor = async (idExecutor) => {
    try {
        const response = await $authHost.delete(`api/executors/${idExecutor}`);
        return response.data;
    } catch (error) {
        console.error('Delete Executor error:', error);
        throw error;
    }
};