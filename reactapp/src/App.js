import React, { Component } from "react";
import { Route, Routes } from "react-router-dom";
import { UserProvider } from "./context/UserContext";

import Index from "./pages/Index";
import Login from "./pages/Login";
import Signup from "./pages/Singup";
import Dashboard from "./pages/Dashboard";
import CreateOuting from "./pages/CreateOuting";
import ViewOuting from "./pages/ViewOuting";
import ViewRestaurant from "./pages/ViewRestaurant";

const App = () => {
  return (
    <div>
      <UserProvider>
        <Routes>
          <Route path="/" element={<Index />}></Route>
          <Route path="/login" element={<Login />}></Route>
          <Route path="/signup" element={<Signup />}></Route>
          <Route path="/dashboard" element={<Dashboard />}></Route>
          <Route path="/create-outing" element={<CreateOuting />} />
          <Route path="/view-outing/:id" element={<ViewOuting />} />
          <Route path="/view-restaurant" element={<ViewRestaurant />} />
        </Routes>
      </UserProvider>
    </div>
  );
};

export default App;
