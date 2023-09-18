import React, { useContext } from "react";
import OutingCard from "../components/OutingCard";
import SideDrawer from "../components/SideDrawer";
import { UserContext } from "../context/UserContext";
import { Link } from "react-router-dom";

const sampleData = {
  name: "Tornado Ramen",
  address: "1234 Address St, CA 11111",
  outings: [
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
        username: "Alice",
        image: "imagePath",
        description: "I would like to try their dumplings!!",
      },
      restaurant: {
        name: "Tornado Ramen",
        address: "1234 Address St. Address, CA 11111",
      },
      date: "2023-08-19",
      time: "6:30 pm",
      accompany: 2,
    },
  ],
};

const ViewRestaurant = () => {
  const { user } = useContext(UserContext);
  if (!user) {
    return (
      <div className="pt-32 text-center">
        <h1 className="bold text-3xl mb-10">FoodieMe</h1>
        <h1 className="text-2xl">Please login..</h1>
        <Link className="text-blue-600 text-lg" to="/login">
          Login
        </Link>
      </div>
    );
  }
  return (
    <div className="text-center">
      <SideDrawer />
      <h1 className="text-4xl m-5">{sampleData.name}</h1>
      <div className="w-2/3 mx-auto max-w-[600px]">
        <img src="https://res.cloudinary.com/dmaijlcxd/image/upload/v1670714105/cld-sample-4.jpg"></img>
      </div>
      <h2 className="text-xl m-5">{sampleData.address}</h2>

      <div>
        <h2 className="text-2xl text-left text-bold m-5">Who's eating here?</h2>
        <div>
          {sampleData.outings.map((outing, index) => {
            return <OutingCard key={index} outing={outing} />;
          })}
        </div>
      </div>
    </div>
  );
};

export default ViewRestaurant;
