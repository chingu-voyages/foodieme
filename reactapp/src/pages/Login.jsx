import React from "react";
import { Link } from "react-router-dom";

const Login = () => {
  return (
    <div>
      <h1>Login</h1>
      <ul>
        <li>
          <Link to="/dashboard" className="text-blue-700">
            Login(to Dashboard)
          </Link>
        </li>
        <li>
          <Link to="/signup" className="text-blue-700">
            Signup
          </Link>
        </li>
      </ul>
    </div>
  );
};

export default Login;
