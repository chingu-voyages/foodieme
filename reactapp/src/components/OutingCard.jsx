import React from "react";
import { formatDate } from "../utils/utils";

const OutingCard = ({ outing }) => {
  return (
    <div className="bg-white shadow-md rounded text-left w-2/3 px-8 pt-6 pb-6 mb-4 mx-auto gap-5">
      <h1>
        <span className="font-bold">{outing.poster.username} </span>
        wants to eat here
      </h1>
      <h1>
        On <span className="font-bold">{formatDate(outing.date)} </span>
      </h1>
      <h1>
        {" "}
        and is looking for{" "}
        <span className="font-bold">{outing.accompany} companions</span>
      </h1>
      <div className="flex mt-3 justify-center">
        <button
          className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-1 px-3 rounded focus:outline-none focus:shadow-outline"
          type="submit"
        >
          Join
        </button>
      </div>
    </div>
  );
};

export default OutingCard;
