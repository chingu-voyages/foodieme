import React from "react";
import { Link } from "react-router-dom";

const Singup = () => {
  return (
    <div>
      <h1>Signup</h1>
      <ul>
        <li>
          <Link to="/dashboard" className="text-blue-700">
            Singup(to Dashboard)
          </Link>
        </li>
        <li>
          <Link to="/login" className="text-blue-700">
            Login
          </Link>
        </li>
      </ul>
    </div>
  );
};

export default Singup;
