import "./Option.css"
import React from "react"
import { Link } from "react-router-dom"

function Option() {
    return (
        <div className="option">
            <Link to="/login">Logout</Link>
        </div>
    )
}

export default Option