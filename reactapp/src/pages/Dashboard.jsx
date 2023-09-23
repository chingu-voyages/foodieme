import React, { useContext, useState, useEffect } from "react";
import { UserContext } from "../context/UserContext";
import { useNavigate, userNavigate, Link } from "react-router-dom";
import OutingCard from "../components/OutingCard";
import SideDrawer from "../components/SideDrawer";
import UpcomingOutingCard from "../components/UpcomingOutingCard";
import axios from "axios";
import { baseUrl } from "../constant";

const Dashboard = () => {
  const navigate = useNavigate();
  const { user, headers } = useContext(UserContext);
  const [myOutings, setMyOutings] = useState([]);
  const [outings, setOutings] = useState([]);
  useEffect(() => {
    const fetchData = async () => {
      try {
        if (headers) {
          const response = await axios.get(`${baseUrl}/api/mealrequests`, {
            headers: headers,
          });
          // sort out outings
          const yourOutings = [];
          const otherOutings = [];
          for (let outing of response.data) {
            if (outing.CreatorId === user.sub) {
              outing["isOwn"] = true;
              yourOutings.push(outing);
            } else if (outing.CompanionsId.indexOf(user.sub) !== -1) {
              outing["isOwn"] = false;
              yourOutings.push(outing);
            } else {
              otherOutings.push(outing);
            }
          }
          setMyOutings(yourOutings);
          setOutings(otherOutings);
        }
      } catch (err) {
        console.error(err);
      }
    };
    fetchData();
  }, []);
  const moveToCreateOuting = () => {
    navigate("/create-outing");
  };
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
    <div className="text-center pt-16">
      <SideDrawer />
      <h1 className="font-extrabold text-[50px] w-full">FoodieMe</h1>
      <p className="font-light mt-[-10px]">Find someone to eat with you!</p>
      <h2 className="mt-5 font-bold italic">Your upcoming foodie outing</h2>
      <div>
        {myOutings.map((outing, index) => {
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
        {outings.map((outing, index) => {
          return <OutingCard key={index} outing={outing} />;
        })}
      </div>
    </div>
  );
};

export default Dashboard;
