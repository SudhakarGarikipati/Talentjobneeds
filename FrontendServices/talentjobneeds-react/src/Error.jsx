import { useRouteError, isRouteErrorResponse } from "react-router-dom";

const Error = () => {
    const err = useRouteError();

    let message = "Something went wrong";

    // if (isRouteErrorResponse(err)) {
    //     message = err.statusText || err.data || message;
    // } else if (err instanceof Error) {
    //     message = err.message;
    // } else if (typeof err === "string") {
    //     message = err;
    // }

    return (
        <fieldset className="fielset">
            <h3>Opp..! Got a problem.!</h3>
            <h4>{message}</h4>
        </fieldset>
    );
};

export default Error;
