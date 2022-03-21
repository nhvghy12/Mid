import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { BsSearch } from "react-icons/bs";
// import bootstrap
import Table from "react-bootstrap/Table";
import Button from "react-bootstrap/Button";

export default function PostPage() {
  const [data, setData] = useState([]);
  const [sortType, setSortType] = useState("Title -- Sort (NONE)");
  const type = {
    NONE: "Title -- Sort (NONE)",
    DESC: "Title -- Sort (DESC)",
    ASC: "Title -- Sort (ASC)",
  };
  const [searchText, setSearchText] = useState("");

  const token = localStorage.getItem("token");

  useEffect(() => {
    const header = {};
    if (token) {
      header["Authorization"] = token;
    }

    fetch("https://jsonplaceholder.typicode.com/posts", {
      method: "GET",
      headers: header,
    })
      .then(function (response) {
        return response.json();
      })
      .then(function (json) {
        setData(json);
      });
  }, [token]);

  function onRemoveClicked(event) {
    event.preventDefault();

    setData(() => data.filter((data) => data.id != event.target.value));
  }
  function handleSort() {
    let sortPosts;
    setSortType(sortType === type.NONE ? type.ASC : type.DESC);
    if (sortType === type.DESC) setSortType(type.NONE);

    switch (sortType) {
      case type.NONE:
        sortPosts = data.sort(function (a, b) {
          if (a.title > b.title) {
            return 1;
          } else if (a.title < b.title) {
            return -1;
          } else {
            return 0;
          }
        });
        setData(sortPosts);
        break;
      case type.ASC:
        sortPosts = data.sort(function (a, b) {
          if (a.title > b.title) {
            return -1;
          } else if (a.title < b.title) {
            return 1;
          } else {
            return 0;
          }
        });
        setData(sortPosts);
        break;
      case type.DESC:
        sortPosts = data.sort(function (a, b) {
          return a.id - b.id;
        });
        break;
      default:
        break;
    }
  }
  const searchPosts =data.filter(p => p.title.toLowerCase().includes(searchText.toLowerCase()))
  return (
    <div>
      <div>
      <input onChange={evt => setSearchText(evt.target.value)} type="search" placeholder='search by title' style={{ margin: '10px' }}></input>
      <BsSearch/>
      </div>
      <div>
        <Table striped bordered hover>
          <thead>
            <tr>
              <th>ID</th>
              <th onClick={handleSort}> {sortType}</th>
              <th>Action</th>
            </tr>
          </thead>
          <tbody>
            {searchPosts.map((row) => (
              <tr key={row.id}>
                <td>{row.id}</td>
                <td>{row.title}</td>
                <td>
                  <div>
                    <Button href={`/posts/${row.id}`} variant="primary">
                      View detail
                    </Button>{" "}
                    {/* <Link to={`/posts/${row.id}`}>View detail</Link> */}
                    <Button
                      variant="danger"
                      value={row.id}
                      onClick={onRemoveClicked}
                    >
                      Remove
                    </Button>
                  </div>
                </td>
              </tr>
            ))}
          </tbody>
        </Table>
      </div>
    </div>
  );
}
