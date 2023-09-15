import React from "react";

const PosterCard = ({ poster }) => {
  const { username } = poster;
  return (
    <div className="bg-white shadow-md rounded px-8 pt-6 pb-6 mb-4 mr-2 ml-2 flex flex-row items-center gap-5">
      <img
        src="https://res.cloudinary.com/dmaijlcxd/image/upload/v1672779743/avatar_mwf06b.jpg"
        alt="avater"
        className="rounded-full w-[50px] h-[50px]"
      ></img>
      <div>
        <h1>
          Hi, I'm
          <span className="font-bold"> {username}</span>
          <p className="mt-3 italic">{poster.description}</p>
        </h1>
      </div>
    </div>
  );
};

export default PosterCard;
