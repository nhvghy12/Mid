import React, { useState, useEffect } from "react";
import LoginPage from "../loginPage/loginPage";

export default function ProfilePage() {
  const [userInfo, setUserInfo] = useState();
  const token = localStorage.getItem("token");
  const userId = localStorage.getItem("userId");

  useEffect(() => {
    if (token && userId) {
      fetch(`https://60dff0ba6b689e001788c858.mockapi.io/users/${userId}`, {
        method: "GET",
        headers: {
          Authorization: token,
        },
      })
        .then(function (response) {
          return response.json();
        })
        .then(function (json) {
          setUserInfo(json);
        });
    }
  }, [token, userId]);

  return token ? (
    <div>
      Name: {userInfo?.name} <br />
      UseId: {userInfo?.id}
    </div>
  ) : (
    <div>
      <b>You need login to continue</b>
      <LoginPage />
    </div>  
  );
}
