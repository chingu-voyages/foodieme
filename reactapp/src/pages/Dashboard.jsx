import React from "react";
import { Link } from "react-router-dom";

const Dashboard = () => {
  return (
    <div>
      <h1>Dashboard</h1>
      <ul>
        <li>
          <Link to="/create-outing" className="text-blue-700">
            Create Outing
          </Link>
        </li>
        <li>
          <Link to="/view-outing" className="text-blue-700">
            View Outings
          </Link>
        </li>
        <li>
          <Link to="/view-restaurant" className="text-blue-700">
            View Restaurant
          </Link>
        </li>
      </ul>
    </div>
  );
};

export default Dashboard;
