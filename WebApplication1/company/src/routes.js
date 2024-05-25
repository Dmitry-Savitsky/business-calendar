import MainPage from "./pages/MainPage";
import FAQPage from "./pages/FAQPage"
import Auth from "./pages/Auth";


import ExecutorsPage from "./pages/ExecutorsPage";
import ServicesPage from "./pages/ServicesPage";
import OrdersPage from "./pages/OrdersPage";
import ReviewsPage from "./pages/ReviewsPage";

import {
  EXECUTORS_ROUTE,
  ORDERS_ROUTE,
  LOGIN_ROUTE,
  REGISTRATION_ROUTE,
  SERVICES_ROUTE,
  FAQ_ROUTE,
  MAIN_ROUTE,
  REVIEWS_ROUTE
} from "./utils/consts";

export const authRoutes = [
  {
    path: EXECUTORS_ROUTE,
    Component: ExecutorsPage,
  },
  {
    path: SERVICES_ROUTE,
    Component: ServicesPage,
  },
  {
    path: ORDERS_ROUTE,
    Component: OrdersPage,
  },
  {
    path: REVIEWS_ROUTE,
    Component: ReviewsPage,
  },
];

export const publicRoutes = [
  {
    path: MAIN_ROUTE,
    Component: MainPage,
  },
  {
    path: FAQ_ROUTE,
    Component: FAQPage,
  },
  {
    path: LOGIN_ROUTE,
    Component: Auth,
  },
  {
    path: REGISTRATION_ROUTE,
    Component: Auth,
  }
];
