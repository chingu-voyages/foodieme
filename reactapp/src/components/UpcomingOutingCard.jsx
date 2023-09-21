import React from "react";
import { formatDate } from "../utils/utils";

const UpcomingOutingCard = ({ outing }) => {
  // check my outing from login account info
  const isMyOuting = outing.poster.username === "me" ? true : false;
  return (
    <div className="bg-white shadow-md rounded text-left w-2/3 px-8 pt-6 pb-6 mb-4 mx-auto gap-5">
      <h1>
        {isMyOuting ? (
          <>You're going to eat at </>
        ) : (
          <>
            You'e joining{" "}
            <span className="font-bold">{outing.poster.username} </span> at{" "}
          </>
        )}
        <span className="font-bold">{outing.restaurant.name}</span>
      </h1>
      <h1>
        On <span className="font-bold">{formatDate(outing.date)} </span>
      </h1>
      <h1>
        at <span className="font-bold">{outing.time} </span>
      </h1>
      <h1>
        {isMyOuting ? (
          <>
            with{" "}
            <span className="font-bold">
              {outing.joined}/{outing.accompany}
            </span>{" "}
            companions
          </>
        ) : null}
      </h1>
    </div>
  );
};

export default UpcomingOutingCard;
