// import { $host } from ".";
// const API_BASE_URL = 'api/accountings/';

// export const createAccounting = async (accounting) => {
//     try {
//         const { data } = await $host.post(`${API_BASE_URL}`, accounting);
//         return data;
//     } catch (error) {
//         console.error('Error creating accounting:', error);
//         throw error; // Propagate the error for handling in the calling code
//     }
// };

// export const getAllAccountings = async () => {
//     const { data } = await $host.get(`${API_BASE_URL}`);
//     return data;
// };

// export const getAllAccountingsByClientId = async (clientId) => {
//     try {
//         const { data } = await $host.get(`${API_BASE_URL}${clientId}`);
//         return data;
//     } catch (error) {
//         throw new Error('Error fetching accountings');
//     }
// };


// export const getOneAccounting = async (id) => {
//     const { data } = await $host.get(`${API_BASE_URL}${id}`);
//     return data;
// };

// export const deleteAccounting = async (id) => {
//     const { data } = await $host.delete(`${API_BASE_URL}${id}`);
//     return data;
// };

// export const updateAccounting = async (id, accounting) => {
//     const { data } = await $host.put(`${API_BASE_URL}${id}`, accounting);
//     return data;
// };
