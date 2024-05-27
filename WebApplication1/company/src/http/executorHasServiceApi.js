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

export const fetchExecutorHasServices = async () => {
    try {
        const response = await $authHost.get(`api/executorhasservices`);
        return response.data;
    } catch (error) {
        console.error('Fetch ExecutorHasServices error:', error);
        throw error;
    }
};

export const fetchExecutorHasService = async (idExecutor, idService) => {
    try {
        const response = await $authHost.get(`api/executorhasservices/${idExecutor}/${idService}`);
        return response.data;
    } catch (error) {
        console.error('Fetch ExecutorHasService error:', error);
        throw error;
    }
};

export const createExecutorHasService = async (executorHasServiceData) => {
    try {
        const response = await $authHost.post('api/executorhasservices', executorHasServiceData);
        return response.data;
    } catch (error) {
        console.error('Create ExecutorHasService error:', error);
        throw error;
    }
};

export const deleteExecutorHasService = async (idExecutor, idService) => {
    try {
        const response = await $authHost.delete(`api/executorhasservices/${idExecutor}/${idService}`);
        return response.data;
    } catch (error) {
        console.error('Delete ExecutorHasService error:', error);
        throw error;
    }
};