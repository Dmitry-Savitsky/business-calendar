// Auth.js
import React, { useContext, useState } from 'react';
import { observer } from 'mobx-react-lite';
import { useNavigate, useLocation, NavLink } from 'react-router-dom';
import { Form, Button } from 'react-bootstrap';
import { Context } from '../index';
import { registration, login } from '../http/userApi';
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { LOGIN_ROUTE, REGISTRATION_ROUTE } from '../utils/consts';

const Auth = observer(() => {
  const location = useLocation();
  const isLogin = location.pathname === LOGIN_ROUTE;
  const { user } = useContext(Context);
  const navigate = useNavigate();

  const [loginData, setLogin] = useState('');
  const [password, setPassword] = useState('');
  const [companyName, setCompanyName] = useState('');
  const [companyPhone, setCompanyPhone] = useState('');
  const [companyAddress, setCompanyAddress] = useState('');

  const handleLogin = async () => {
    try {
      const data = await login(loginData, password);
      user.setUser(data);
      user.setIsAuth(true);
      navigate('/'); // Redirect to home page or dashboard after login
    } catch (e) {
      toast.error(e.response.data.message);
    }
  };

  const handleRegister = async () => {
    try {
      const data = await registration(companyName, companyPhone, companyAddress, loginData, password);
      user.setUser(data);
      user.setIsAuth(true);
      navigate('/'); // Redirect to home page or dashboard after registration
    } catch (e) {
      toast.error(e.response.data.message);
    }
  };

  return (
    <div className="auth-page">
      <Form>
        <h2>{isLogin ? 'Login' : 'Register'}</h2>
        <Form.Control
          type="text"
          placeholder="Login"
          value={loginData}
          onChange={(e) => setLogin(e.target.value)}
        />
        <Form.Control
          type="password"
          placeholder="Password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
        {!isLogin && (
          <>
            <Form.Control
              type="text"
              placeholder="Company Name"
              value={companyName}
              onChange={(e) => setCompanyName(e.target.value)}
            />
            <Form.Control
              type="text"
              placeholder="Company Phone"
              value={companyPhone}
              onChange={(e) => setCompanyPhone(e.target.value)}
            />
            <Form.Control
              type="text"
              placeholder="Company Address"
              value={companyAddress}
              onChange={(e) => setCompanyAddress(e.target.value)}
            />
          </>
        )}
        <Button onClick={isLogin ? handleLogin : handleRegister}>
          {isLogin ? 'Login' : 'Register'}
        </Button>
        {isLogin ? (
          <NavLink to= {REGISTRATION_ROUTE}>Need an account?</NavLink>
        ) : (
          <NavLink to="/login">Already have an account?</NavLink>
        )}
      </Form>
      <ToastContainer />
    </div>
  );
});

export default Auth;