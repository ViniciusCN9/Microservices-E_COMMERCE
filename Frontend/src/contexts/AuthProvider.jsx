import { createContext } from "react"

export const AuthContext = createContext()

export const AuthProvider = function ({ children }) {
    function authenticate(token) {
        localStorage.setItem("token", token)
    }

    function authorize(role, username) {
        localStorage.setItem("role", role)
        localStorage.setItem("username", username)
    }

    return (
        <AuthContext.Provider value={{ authenticate, authorize }}>
            {children}
        </AuthContext.Provider>
    )
}

export default AuthContext