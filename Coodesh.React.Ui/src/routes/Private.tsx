import { useEffect, useState } from "react";
import { Navigate } from "react-router-dom";

export default function Provate({ children }: any) {
    const [loading, setLoading] = useState(true);
    const [signed, setSigned] = useState(false);

    useEffect(() => {
        async function checkLogin() {
            const storedUser = localStorage.getItem("@detailUser");

            if (storedUser) {
                try {
                    const sub: { email: string, senha: string } = JSON.parse(storedUser);
                    if (sub.email && sub.senha) {
                        setLoading(false);
                        setSigned(true);
                    } else {
                        setLoading(false);
                        setSigned(false);
                    }
                } catch (error) {
                    setLoading(false);
                    setSigned(false);
                }
            } else {
                setLoading(false);
                setSigned(false);
            }
        }

        checkLogin();
    }, []);


    if (loading) {
        return (
            <div></div>
        )
    }

    if (!signed) {
        return <Navigate to="/" />
    }

    return children;
}