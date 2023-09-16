import React from "react";
import { useNavigate, userNavigate } from "react-router-dom";
import OutingCard from "../components/OutingCard";
import { formatDate } from "../utils/utils";
import UpcomingOutingCard from "../components/UpcomingOutingCard";
const sampleData = [
  {
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
  },
  {
    poster: {
      username: "Sam",
      image: "imagePath",
      description: "I would like to try new cuisines!!",
    },
    restaurant: {
      name: "Steak House",
      address: "45 Spence St. Address, CA 11111",
    },
    date: "2023-08-18",
    time: "12:30 pm",
    accompany: 5,
  },
];

const yourOutings = [
  {
    poster: {
      username: "me",
      image: "imagePath",
      description: "I would like to try new cuisines!!",
    },
    restaurant: {
      name: "Crane DC",
      address: "1234 Address St. Address, CA 11111",
    },
    date: "2023-08-20",
    time: "12:30 pm",
    joined: 2,
    accompany: 3,
  },
  {
    poster: {
      username: "Bob",
      image: "imagePath",
      description: "I would like to try new cuisines!!",
    },
    restaurant: {
      name: "Milk & Honey",
      address: "1234 Address St. Address, CA 11111",
    },
    date: "2023-08-20",
    time: "11:00 am",
    joined: 1,
    accompany: 4,
  },
];

const Dashboard = () => {
  const navigate = useNavigate();
  const moveToCreateOuting = () => {
    navigate("/create-outing");
  };

  return (
    <div className="text-center pt-16">
      <h1 className="font-extrabold text-[50px] w-full">FoodieMe</h1>
      <p className="font-light mt-[-10px]">Find someone to eat with you!</p>
      <h2 className="mt-5 font-bold italic">Your upcoming foodie outing</h2>
      <div>
        {yourOutings.map((outing, index) => {
          return <UpcomingOutingCard key={index} outing={outing} />;
        })}
      </div>
      <button
        className="bg-blue-500 hover:bg-blue-700 text-white font-bold my-10 py-2 px-4 rounded focus:outline-none focus:shadow-outline"
        type="button"
        onClick={moveToCreateOuting}
      >
        Create a new foodie outing
      </button>
      <h3>or</h3>
      <h2 className="mt-5 font-bold italic">join a foodie outing near you</h2>
      <div>
        {sampleData.map((outing, index) => {
          return <OutingCard key={index} outing={outing} />;
        })}
      </div>
    </div>
  );
};

export default Dashboard;
