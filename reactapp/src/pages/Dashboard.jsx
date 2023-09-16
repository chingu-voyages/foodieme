import React from "react";
import { Link } from "react-router-dom";
import UpcomingOutingCard from "../components/UpcomingOutingCard";

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
    </div>
  );
};

export default Dashboard;
