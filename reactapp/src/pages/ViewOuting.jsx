import React from "react";
import PosterCard from "../components/PosterCard";
import { formatDate } from "../utils/utils";
const sampleData = {
  poster: {
    username: "Bob",
    image: "imagePath",
    description: "I would like to try new cuisines!!",
  },
  restaurant: {
    name: "Tornado Ramen",
    address: "1234 Address St. Address, CA 11111",
  },
  date: "2023-08-17",
  time: "12:30 pm",
  accompany: 3,
};

const ViewOuting = () => {
  return (
    <div className="p-10">
      <h1 className="text-2xl mb-3 font-bold text-center">Join Outing</h1>
      <PosterCard poster={sampleData.poster} />
      <h3 className="text-lg text-center mt-5 mb-5">
        I want to eat at{" "}
        <span className="font-bold">{sampleData.restaurant.name}</span>
      </h3>
      <div className="w-2/3 mx-auto max-w-[600px]">
        <img src="https://res.cloudinary.com/dmaijlcxd/image/upload/v1670714105/cld-sample-4.jpg"></img>
      </div>
      <div className="text-center mt-5 mb-5">
        <h3>
          On <span className="font-bold">{formatDate(sampleData.date)}</span>
        </h3>
        <h3>
          and am looking for{" "}
          <span className="font-bold">
            {sampleData.accompany} people to join me!
          </span>
        </h3>
      </div>
      <div className="flex items-center justify-center">
        <button
          className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
          type="submit"
        >
          I'd like to join {sampleData.poster.username}
        </button>
      </div>
    </div>
  );
};

export default ViewOuting;
