import React, { useContext } from "react";
import { formatDate } from "../utils/utils";
import { UserContext } from "../context/UserContext";
import { baseUrl } from "../constant";
import axios from "axios";

const UpcomingOutingCard = ({ outing }) => {
  const { headers } = useContext(UserContext);
  const handleDelete = () => {
    const deleteOuting = async () => {
      try {
        await axios.delete(`${baseUrl}/api/MealRequests/${outing.Id}`, {
          headers,
        });
        console.log(outing.Id + " was deleted");
      } catch (err) {
        console.log(err);
      }
    };
    deleteOuting();
  };

  const isMyOuting = outing.isOwn;
  return (
    <div className="bg-white shadow-md rounded text-left w-2/3 px-8 pt-6 pb-6 mb-4 mx-auto gap-5">
      <h1>
        {isMyOuting ? (
          <>You're going to eat at </>
        ) : (
          <>
            You'e joining{" "}
            <span className="font-bold">{outing.Creator.UserName} </span> at{" "}
          </>
        )}
        <span className="font-bold">{outing.Restaurant.Name}</span>
      </h1>
      <h1>
        On <span className="font-bold">{formatDate(outing.DateTime)} </span>
      </h1>
      <h1>
        {isMyOuting ? (
          <>
            <div>
              with{" "}
              <span className="font-bold">
                {outing.CompanionsId.length}/{outing.NumberOfPeople}
              </span>{" "}
              companions
            </div>
            <div className="flex items-center justify-center">
              <button
                className="bg-red-500 mt-10 hover:bg-red-700 text-white font-bold py-1 px-3 rounded focus:outline-none focus:shadow-outline"
                type="submit"
                onClick={handleDelete}
              >
                Delete
              </button>
            </div>
          </>
        ) : null}
      </h1>
    </div>
  );
};

export default UpcomingOutingCard;
