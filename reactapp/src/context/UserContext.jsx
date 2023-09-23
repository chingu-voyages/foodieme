import React, { createContext, useState } from "react";

const UserContext = createContext();
const UserProvider = ({ children }) => {
  const [user, setUser] = useState(null);
  const [headers, setHeaders] = useState(null);

  const login = (userData, token) => {
    setUser(userData);
    setHeaders({
      Authorization: `Bearer ${token}`,
      "Content-Type": "application/json",
    });
  };
  const logout = () => {
    setUser(null);
    setHeaders(null);
  };
  const contextValue = {
    user,
    headers,
    login,
    logout,
  };
  return (
    <UserContext.Provider value={contextValue}>{children}</UserContext.Provider>
  );
};

export { UserContext, UserProvider };
