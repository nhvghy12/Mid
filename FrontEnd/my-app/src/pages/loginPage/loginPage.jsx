import React, { useState } from "react";
import validator from "validator";
import { useNavigate } from "react-router-dom";


// import Bootstrap
import Form from "react-bootstrap/Form";
import { Button } from "react-bootstrap";

export default function LoginPage() {
  const [email, setEmail] = useState();
  const [password, setPassword] = useState();
  const [emailError, setEmailError] = useState();
  const [passwordError, setPasswordError] = useState();

  const navigate = useNavigate();

  function onEmailChange(newEmail) {
    setEmail(newEmail);
    if (newEmail === "" || newEmail === undefined) {
      setEmailError("required");
      return false;
    } else if (!validator.isEmail(newEmail)) {
      setEmailError("Must be a valid email");
      return false;
    } else {
      setEmailError("");
      return true;
    }
  }
  function onPasswordChange(newPassword) {
    setPassword(newPassword);
    if (newPassword === "" || newPassword === undefined) {
      setPasswordError("required");
      return false;
    } else if (newPassword.length < 8) {
      setPasswordError("At least 8 charaters");
      return false;
    } else {
      setPasswordError("");
      return true;
    }
  }
  function onSubmit() {
    if (onEmailChange(email) && onPasswordChange(password)) {
      fetch('https://60dff0ba6b689e001788c858.mockapi.io/token', {
        method: "GET",
      })
        .then(function (response) {
          return response.json();
        })
        .then(function (json) {
          const { token, userId } = json;
          localStorage.setItem('token', token);
          localStorage.setItem('userId', userId);
          navigate('/profile'); 
          window.location.reload();
        });
    }
  }

  return (
    <div>
      <Form>
        <Form.Group className="mb-3" controlId="formBasicEmail">
          <Form.Label>Email address</Form.Label>
          <Form.Control
            value={email}
            onChange={(e) => onEmailChange(e.target.value)}
            type="email"
            placeholder="Enter email"
          />
          <div>
            {emailError && <span style={{ color: "red" }}>{emailError}</span>}
          </div>
        </Form.Group>

        <Form.Group className="mb-3" controlId="formBasicPassword">
          <Form.Label>Password</Form.Label>
          <Form.Control
            value={password}
            onChange={(e) => onPasswordChange(e.target.value)}
            type="password"
            placeholder="Password"
          />
          <div>
            {passwordError && (
              <span style={{ color: "red" }}>{passwordError}</span>
            )}
          </div>
        </Form.Group>
        <Button onClick={onSubmit} variant="primary" >
          Submit
        </Button>
      </Form>
    </div>
  );
}
