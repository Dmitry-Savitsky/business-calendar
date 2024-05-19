import React, { createContext } from 'react';
import { createRoot } from 'react-dom/client'; // Import createRoot from react-dom/client
import App from './App';
import UserStore from './store/UserStore';
import 'bootstrap/dist/css/bootstrap.min.css';

export const Context = createContext(null);

// Use createRoot from react-dom/client
createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <Context.Provider value={{ user: new UserStore() }}>
      <App />
    </Context.Provider>
  </React.StrictMode>,
);
