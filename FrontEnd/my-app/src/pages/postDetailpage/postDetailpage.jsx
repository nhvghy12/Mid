import React, { useState, useEffect } from "react";
import { Params, useParams } from "react-router-dom";

// import bootstrap
import Card from "react-bootstrap/Card";

export default function PostDetailPage() {
  const postId = useParams().id;
  console.log(postId);
  const [data, setData] = useState([]);
  const token = localStorage.getItem("token");

  useEffect(() => {
    const header = {};
    if (token) {
      header["Authorization"] = token;
    }
    fetch(`https://jsonplaceholder.typicode.com/posts/${postId}`, {
      method: "GET",
      headers: header
    })
      .then(function (response) {
        return response.json();
      })
      .then(function (json) {
        setData(json);
      });
  }, [token]);

  return (
    <div>
      <Card className="bg-dark text-white">
        <Card.Img
          src="https://s3.cloud.cmctelecom.vn/tinhte1/2018/04/4281321_DSCF2312-5.jpg"
          alt="Card image"
        />
        <Card.ImgOverlay>
          <Card.Title>ID : {data?.id}</Card.Title>
          <Card.Title>Title: {data?.title}</Card.Title>
          <Card.Text>Body: {data?.body}</Card.Text>
        </Card.ImgOverlay>
      </Card>
      {/* <div>ID: {data?.id}</div> */}
    </div>
  );
}
