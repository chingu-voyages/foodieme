import React, { useContext, useState, useEffect } from "react";
import PosterCard from "../components/PosterCard";
import { UserContext } from "../context/UserContext";
import { Link, useParams } from "react-router-dom";
import { formatDate, getImage } from "../utils/utils";
import SideDrawer from "../components/SideDrawer";
import axios from "axios";
import { baseUrl } from "../constant";

const ViewOuting = () => {
  const { user, headers } = useContext(UserContext);
  const [outing, setOuting] = useState(null);
  const { id } = useParams();
  const [restaurants, setRestaurants] = useState([]);
  const handleJoinClick = () => {
    const joinOuting = async () => {
      try {
        console.log(headers);
        const res = axios.patch(`${baseUrl}/api/MealRequests/${id}/join`, {
          headers: headers,
        });
        setRestaurants(res.data);
      } catch (err) {
        console.log(err);
      }
    };
    joinOuting();
  };
  useEffect(() => {
    const fetchData = async () => {
      if (headers) {
        try {
          const res = await axios.get(`${baseUrl}/api/MealRequests/${id}`, {
            headers: headers,
          });
          console.log(res.data);
          setOuting(res.data);
        } catch (err) {
          console.log(err);
        }
      }
    };
    fetchData();
  }, []);

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
    <div className="p-10">
      <SideDrawer />
      <h1 className="text-2xl mb-3 font-bold text-center">Join Outing</h1>
      <PosterCard poster={outing?.Creator} />
      <h3 className="text-lg text-center mt-5 mb-5">
        I want to eat at{" "}
        <Link
          to={`/view-restaurant/${outing?.Restaurant.Id}`}
          className="font-bold underline"
        >
          {outing?.Restaurant.Name}
        </Link>
      </h3>
      <div className="w-2/3 mx-auto max-w-[600px]">
        <img src={getImage(`${outing?.Restaurant.Style}`)}></img>
      </div>
      <div className="text-center mt-5 mb-5">
        <h3>
          On{" "}
          <span className="font-bold">
            {outing && formatDate(outing?.DateTime)}
          </span>
        </h3>
        <h3>
          and am looking for{" "}
          <span className="font-bold">
            {outing?.NumberOfPeople} people to join me!
          </span>
        </h3>
      </div>
      <div className="flex items-center justify-center">
        <button
          className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
          type="button"
          onClick={handleJoinClick}
        >
          I'd like to join {outing?.Creator.UserName}
        </button>
      </div>
    </div>
  );
};

export default ViewOuting;
