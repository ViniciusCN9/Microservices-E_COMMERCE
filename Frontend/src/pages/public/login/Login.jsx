import "./Login.css"
import React, { useState, useEffect } from "react"
import axios from "../../../api/axios"
import { Link, useNavigate, useLocation } from 'react-router-dom';
import useAuth from "../../../hooks/useAuth";

const LOGIN_URL = "/Access/Login"

function Login() {
    const { authenticate } = useAuth()

    const navigate = useNavigate();
    const location = useLocation();
    const from = location.state?.from?.pathname || "/auth";

    const [username, setUsername] = useState("")
    const [password, setPassword] = useState("")
    const [error, setError] = useState("")

    useEffect(() => {
        setError("");
    }, [username, password])

    function handleSubmit(e) {
        e.preventDefault()

        axios.post(LOGIN_URL, JSON.stringify({ username, password }), { headers: { 'Content-Type': 'application/json' } })
            .then(response => {
                authenticate(response.data.token)
                navigate(from, { replace: true })
            })
            .catch(error => setError(error.response.data))
    }

    return (
        <div className="login">
            <h1>Login</h1>
            <div className={error ? "error" : "off"}>
                <p>{error}</p>
            </div>
            <form className="form" onSubmit={handleSubmit}>
                <div className="field">
                    <label htmlFor="username">Username</label>
                    <input
                        type="username"
                        name="username"
                        id="username"
                        value={username}
                        onChange={e => setUsername(e.target.value)}
                        required
                    />
                </div>
                <div className="field">
                    <label htmlFor="password">Password</label>
                    <input
                        type="password"
                        name="password"
                        id="password"
                        value={password}
                        onChange={e => setPassword(e.target.value)}
                        required
                    />
                </div>
                <div className="actions">
                    <button type="submit">Login</button>
                </div>
                <div className="links">
                    <Link to="/register">Register</Link>
                </div>
            </form>
        </div>
    )
}

export default Login