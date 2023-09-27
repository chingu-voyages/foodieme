import React, { useContext, useState, useEffect } from "react";
import PosterCard from "../components/PosterCard";
import { UserContext } from "../context/UserContext";
import { useNavigate, Link, useParams } from "react-router-dom";
import { formatDate, getImage } from "../utils/utils";
import SideDrawer from "../components/SideDrawer";
import axios from "axios";
import { baseUrl } from "../constant";

const ViewOuting = () => {
  const { user, headers } = useContext(UserContext);
  const [outing, setOuting] = useState(null);
  const [isYourOuting, setIsYourOuting] = useState(false);
  const [isFull, setIsFull] = useState(false);
  const { id } = useParams();
  const navigate = useNavigate();
  const [restaurants, setRestaurants] = useState([]);
  const handleJoinClick = () => {
    const joinOuting = async () => {
      try {
        const res = await axios.patch(
          `${baseUrl}/api/MealRequests/${id}/join`,
          null,
          {
            headers: headers,
          }
        );
        navigate("/dashboard");
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
          const data = res.data;
          console.log(data.CreatorId, user.sub);
          if (data.CreateroId === user.sub) {
            setIsYourOuting(true);
          }
          if (data.CompanionsId.length === data.NumberOfPeople) {
            setIsFull(true);
          }
          setOuting(data);
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
      <div>
        <img
          className="w-2/3 mx-auto max-w-[500px]"
          src={
            outing?.Restaurant.Style && getImage(`${outing?.Restaurant.Style}`)
          }
        ></img>
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
        {isYourOuting ? null : isFull ? (
          <h1 className="text-green-900 text-2xl italic">Full</h1>
        ) : (
          <button
            className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
            type="button"
            onClick={handleJoinClick}
          >
            I'd like to join {outing?.Creator.UserName}
          </button>
        )}
      </div>
    </div>
  );
};

export default ViewOuting;
