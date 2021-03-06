import "./AllowAny.css"
import React from "react";
import { Outlet } from "react-router-dom"

function AllowAny() {
    localStorage.clear()
    return (
        <main className="allow-any">
            <Outlet />
        </main>
    )
}

export default AllowAny