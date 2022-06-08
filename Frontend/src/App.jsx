import React from "react"
import { Routes, Route } from "react-router-dom";

import AllowAny from "./pages/public/AllowAny";
import RequireAuth from "./pages/private/RequireAuth";

import Login from "./pages/public/login/Login";
import Register from "./pages/public/register/Register"
import Error from "./pages/public/error/Error"
import Main from "./pages/private/main/Main"

import Home from "./pages/private/main/components/Home"
import Catalog from "./pages/private/main/components/Catalog"
import Order from "./pages/private/main/components/Order"

function App() {

    return (
        <Routes>
            <Route path="/" >
                <Route element={<AllowAny />}>
                    <Route path="login" element={<Login />} />
                    <Route path="register" element={<Register />} />
                    <Route path="*" element={<Error />} />
                </Route>
                <Route element={<RequireAuth />}>
                    <Route path="auth" element={<Main />}>
                        <Route path="" element={<Home />} />
                        <Route path="catalog" element={<Catalog />} />
                        <Route path="order" element={<Order />} />
                    </Route>
                </Route>
            </Route>
        </Routes>
    )
}

export default App