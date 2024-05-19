// NavBar.js
import React, { useContext } from 'react';
import { observer } from 'mobx-react-lite';
import { NavLink, useNavigate } from 'react-router-dom';
import { Navbar, Nav, Container, Button } from 'react-bootstrap';
import { Context } from '../index';
import {
  MAIN_ROUTE,
  LOGIN_ROUTE,
  REGISTRATION_ROUTE,
  EXECUTORS_ROUTE,
  SERVICES_ROUTE,
  FAQ_ROUTE,
  ORDERS_ROUTE,
  REVIEWS_ROUTE
} from '../utils/consts';

const NavBar = observer(() => {
  const { user } = useContext(Context);
  const navigate = useNavigate();

  const logout = () => {
    user.setUser({});
    user.setIsAuth(false);
    localStorage.removeItem('token');
    navigate(MAIN_ROUTE);
  };

  return (
    <Navbar bg="dark" variant="dark" expand="lg">
      <Container>
        <Navbar.Brand as={NavLink} to={MAIN_ROUTE}>MyApp</Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="ml-auto">
            {user.isAuth ? (
              <>
                <Nav.Link as={NavLink} to={EXECUTORS_ROUTE}>Executors</Nav.Link>
                <Nav.Link as={NavLink} to={SERVICES_ROUTE}>Services</Nav.Link>
                <Nav.Link as={NavLink} to={ORDERS_ROUTE}>Orders</Nav.Link>
                <Nav.Link as={NavLink} to={REVIEWS_ROUTE}>Reviews</Nav.Link>
                <Nav.Link as={NavLink} to={FAQ_ROUTE}>FAQ</Nav.Link>
                <Button variant="outline-primary" onClick={logout}>Logout</Button>
              </>
            ) : (
              <>
                <Nav.Link as={NavLink} to={FAQ_ROUTE}>FAQ</Nav.Link>
                <Nav.Link as={NavLink} to={LOGIN_ROUTE}>Login</Nav.Link>
                <Nav.Link as={NavLink} to={REGISTRATION_ROUTE}>Register</Nav.Link>
              </>
            )}
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
});

export default NavBar;