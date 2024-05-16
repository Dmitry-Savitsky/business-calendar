import { $host } from ".";
//import { $host } from './http';
import jwtDecode from 'jwt-decode';

export const registration = async (companyName, companyPhone, companyAddress, login, password) => {
    try {
        const { data } = await $host.post('api/auth/register', {
            companyName,
            companyPhone,
            companyAddress,
            login,
            password
        });

        localStorage.setItem('token', data.token);
        localStorage.setItem('isAuth', 'true');

        return jwtDecode(data.token);
    } catch (error) {
        console.error('Registration error:', error);
        throw error;
    }
};

export const login = async (login, password) => {
    try {
        const { data } = await $host.post('api/auth/login', { login, password });

        localStorage.setItem('token', data.token);
        localStorage.setItem('isAuth', 'true');

        return jwtDecode(data.token);
    } catch (error) {
        console.error('Login error:', error);
        throw error;
    }
};