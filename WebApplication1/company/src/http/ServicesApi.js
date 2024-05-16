import { $host } from ".";

const API_BASE_URL = 'api/services/';

export const createService = async (service) => {
    try {
        const { data } = await $host.post(`${API_BASE_URL}`, service);
        return data;
    } catch (error) {
        console.error('Error creating service:', error);
        throw error; // Propagate the error for handling in the calling code
    }
};

export const getAllServices = async () => {
    const { data } = await $host.get(`${API_BASE_URL}`);
    return data;
};

export const getOneService = async (id) => {
    const { data } = await $host.get(`${API_BASE_URL}${id}`);
    return data;
};

export const deleteService = async (id) => {
    const { data } = await $host.delete(`${API_BASE_URL}${id}`);
    return data;
};

export const updateService = async (id, service) => {
    const { data } = await $host.put(`${API_BASE_URL}${id}`, service);
    return data;
};
