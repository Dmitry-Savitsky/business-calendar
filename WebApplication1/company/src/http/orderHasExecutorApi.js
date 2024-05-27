import { $authHost } from ".";

export const fetchOrderHasExecutors = async () => {
    try {
        const response = await $authHost.get('api/orderhasexecutors');
        return response.data;
    } catch (error) {
        console.error('Fetch OrderHasExecutors error:', error);
        throw error;
    }
};

export const fetchOrderHasExecutor = async (idOrder, idExecutor) => {
    try {
        const response = await $authHost.get(`api/orderhasexecutors/${idOrder}/${idExecutor}`);
        return response.data;
    } catch (error) {
        console.error('Fetch OrderHasExecutor error:', error);
        throw error;
    }
};

export const createOrderHasExecutor = async (orderHasExecutorData) => {
    try {
        const response = await $authHost.post('api/orderhasexecutors', orderHasExecutorData);
        return response.data;
    } catch (error) {
        console.error('Create OrderHasExecutor error:', error);
        throw error;
    }
};

export const deleteOrderHasExecutor = async (idOrder, idExecutor) => {
    try {
        const response = await $authHost.delete(`api/orderhasexecutors/${idOrder}/${idExecutor}`);
        return response.data;
    } catch (error) {
        console.error('Delete OrderHasExecutor error:', error);
        throw error;
    }
};