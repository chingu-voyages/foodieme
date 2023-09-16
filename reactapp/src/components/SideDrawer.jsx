import React, { useState } from "react";
import { Link } from "react-router-dom";

const SideDrawer = () => {
  const [isClosed, setIsClosed] = useState(true);
  const handleClick = () => {
    setIsClosed(!isClosed);
  };
  return (
    <div>
      <div className="text-left fixed">
        <button
          className="outline outline-blue-600 ml-5   hover:bg-blue-600 hover:text-white font-bold py-2 px-4 rounded"
          onClick={handleClick}
          disabled={!isClosed}
        >
          Menu
        </button>
      </div>
      {!isClosed && (
        <div className="fixed text-center inset-y-0 left-0 bg-white w-80 dark:bg-gray-800 p-4">
          <button
            className="absolute flex justify-center items-center top-1 right-1 text-lg w-6 h-6 text-center  mt-2 mr-2 hover:bg-slate-200 rounded-full"
            onClick={handleClick}
          >
            X
          </button>
          <ul className="mt-10 text-lg">
            <li>
              <Link to="/dashboard">Dashboard</Link>
            </li>
            <li>
              <Link to="/create-outing">Create Outing</Link>
            </li>
            <li>Settings</li>
          </ul>
          <button
            className="bg-red-500 mt-10 hover:bg-red-700 text-white font-bold py-1 px-3 rounded focus:outline-none focus:shadow-outline"
            type="button"
          >
            Logout
          </button>
        </div>
      )}
    </div>
  );
};

export default SideDrawer;