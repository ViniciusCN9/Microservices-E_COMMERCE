import "./Nav.css"
import React from "react"
import { Link } from "react-router-dom"

function Nav(props) {
    return (
        <div className="nav">
            <Link to="/auth/" className={(props.url === "http://localhost:3000/auth" || props.url === "http://localhost:3000/auth/") ? "selected" : ""}>HOME</Link>
            <Link to="/auth/catalog" className={(props.url === "http://localhost:3000/auth/catalog") ? "selected" : ""}>CATALOG</Link>
            <Link to="/auth/order" className={(props.url === "http://localhost:3000/auth/order") ? "selected" : ""}>ORDER</Link>
        </div>
    )
}

export default Nav

