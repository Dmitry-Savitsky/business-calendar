// import { $host } from ".";
// const API_BASE_URL = 'api/employees/';

// export const createEmployee = async (employee) => {
//     try {
//         const { data } = await $host.post(`${API_BASE_URL}`, employee);
//         return data;
//     } catch (error) {
//         console.error('Error creating employee:', error);
//         throw error; // Propagate the error for handling in the calling code
//     }
// };

// export const getAllEmployees = async () => {
//     const { data } = await $host.get(`${API_BASE_URL}`);
//     return data;
// };

// export const getOneEmployee = async (id) => {
//     const { data } = await $host.get(`${API_BASE_URL}${id}`);
//     return data;
// };

// export const deleteEmployee = async (id) => {
//     const { data } = await $host.delete(`${API_BASE_URL}${id}`);
//     return data;
// };

// export const updateEmployee = async (id, employee) => {
//     const { data } = await $host.put(`${API_BASE_URL}${id}`, employee);
//     return data;
// };
