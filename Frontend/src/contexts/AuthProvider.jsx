import { createContext } from "react"

export const AuthContext = createContext()

export const AuthProvider = function ({ children }) {
    function authenticate(token) {
        localStorage.setItem("token", token)
    }

    return (
        <AuthContext.Provider value={{ authenticate }}>
            {children}
        </AuthContext.Provider>
    )
}

export default AuthContext