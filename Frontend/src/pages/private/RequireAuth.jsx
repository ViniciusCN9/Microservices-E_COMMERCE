import "./RequireAuth.css"
import React from "react"
import { Outlet, Navigate, useLocation } from "react-router-dom"

function RequireAuth() {
    const location = useLocation()

    return (
        localStorage.getItem("token")
            ? <main className="require-auth"> <Outlet /></main>
            : <Navigate to="/login" state={{ from: location }} replace />
    )
}

export default RequireAuth