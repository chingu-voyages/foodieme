import React from "react";
import { Link } from "react-router-dom";

const Index = () => {
  return (
    <div>
      <h1>Index</h1>
      <Link to="/signup" className="text-blue-700">
        Signup Today!!
      </Link>
    </div>
  );
};

export default Index;
