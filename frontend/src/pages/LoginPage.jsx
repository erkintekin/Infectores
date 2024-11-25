import React, { useEffect, useState } from "react";
import { login } from "../APIs/loginAPI";

function Login() {
  //States
  const [mail, setMail] = useState("");
  const [password, setPassword] = useState("");
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");

  const loginHandler = async () => {
    setError("");
    setLoading(true);

    try {
      const data = await login(mail, password);

      console.log("Login successfull!", data);

      // bu kısımda JWT kullanıp token oluşturmak gerekiyor ve tokenı localStorage'a kaydetmemiz lazım
      // localStorage.setItem("token", data.token);
    } catch (error) {
      setError(error);
    } finally {
      setLoading(false); // If login is successfull, false it.
    }
  };

  return (
    <div className="vh-100 d-flex align-items-center justify-content-center">
      <div className="shadow p-3 rounded bg-dark w-25">
        <div className="form-group my-3">
          <label htmlFor="mail">Enter your e-mail</label>
          <input
            type="text"
            className="form-control"
            id="mail"
            aria-describedby="mailDescription"
            placeholder="Please enter your e-mail"
            onChange={(e) => setMail(e.target.value)}
          />
        </div>
        <div className="form-group my-3">
          <label htmlFor="password">Enter your password</label>
          <input
            type="password"
            className="form-control"
            id="password"
            placeholder="Please enter your password"
            onChange={(e) => setPassword(e.target.value)}
          />
        </div>
        <button
          type="submit"
          className="btn btn-primary"
          onClick={loginHandler}
        >
          Login
        </button>
      </div>
    </div>
  );
}

export default Login;
