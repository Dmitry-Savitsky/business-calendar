import axios from "axios";

const $host = axios.create();

const $authHost = axios.create();

const authInterceptor = config => {
    const token = localStorage.getItem('token');
    if (token) {
        config.headers.authorization = `Bearer ${token}`;
    }
    return config;
}

$authHost.interceptors.request.use(authInterceptor);

export {
    $host,
    $authHost
};