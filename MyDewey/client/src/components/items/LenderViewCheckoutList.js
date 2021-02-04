import React, { useEffect, useContext, useState, useRef } from "react";
//import { ListGroup, ListGroupItem, Card, CardImg, CardBody, Button, CardTitle, CardSubtitle, Container } from "reactstrap";
import { useParams, useHistory, Link } from "react-router-dom";
import { Button, CardImg, Form, Table, FormGroup, Label, Input } from "reactstrap";
import { ItemContext } from "../../providers/ItemProvider";


const LenderViewCheckoutList = () => {


    const { lenderViews, GetLenderViewCheckout, VerifyCheckin } = useContext(ItemContext);

    const history = useHistory();


    useEffect(() => {

        GetLenderViewCheckout();
    }, []);

    if (!lenderViews) {
        return null;
    }

    return (
        <>

            <div className="itemList">
                <div className="itemListTop">
                    <h2>Items You're Currently Lending</h2>

                </div>

                {lenderViews.map((lend) => (
                    <div key={lend.id} >
                        {!lend.checkinDate
                            ?
                            <div className="items" >
                                {/* < Link to={`item detai page TODO`}> */}
                                <p>Item Name: {lend.itemName}</p>
                                <p>Borrower: {lend.borrowerUserName}</p>
                                <p>{lend.checkoutDate && `Checked out at ${new Date(lend.checkoutDate).getHours() > 12 ? new Date(lend.checkoutDate).getHours() - 12 : new Date(lend.checkoutDate).getHours()}:${new Date(lend.checkoutDate).getHours() > 12 ? new Date(lend.checkoutDate).getMinutes() + " PM" : new Date(lend.checkoutDate).getMinutes() + " AM"} on ${new Date(lend.checkoutDate).getMonth() + 1}/${new Date(lend.checkoutDate).getDate()}/${new Date(lend.checkoutDate).getFullYear()}`}</p>

                                <p>{lend.dueDate && `Due by ${new Date(lend.dueDate).getHours() > 12 ? new Date(lend.dueDate).getHours() - 12 : new Date(lend.dueDate).getHours()}:${new Date(lend.dueDate).getHours() > 12 ? new Date(lend.dueDate).getMinutes() + " PM" : new Date(lend.dueDate).getMinutes() + " AM"} on ${new Date(lend.dueDate).getMonth() + 1}/${new Date(lend.dueDate).getDate()}/${new Date(lend.dueDate).getFullYear()}`}</p>
                                {/* <Image fluid rounded src={sample.image} alt={sample.name}></Image> */}

                                {/* <ReactImageFallback
                                width="100%"
                                src={`/api/image/${item.image}`}
                                fallbackImage={item.image}
                                alt={sample.name} /> */}
                                {/* </Link> */}


                            </div>
                            :
                            <div className="requestQueue" >
                                {/* < Link to={`item detai page TODO`}> */}
                                <p>{lend.checkinDate && "Awaiting Return Verification"}</p>
                                <p>Item Name: {lend.itemName}</p>
                                <p>borrower: {lend.borrowerUserName}</p>
                                <p>{lend.checkoutDate && `Checked out at ${new Date(lend.checkoutDate).getHours() > 12 ? new Date(lend.checkoutDate).getHours() - 12 : new Date(lend.checkoutDate).getHours()}:${new Date(lend.checkoutDate).getHours() > 12 ? new Date(lend.checkoutDate).getMinutes() + " PM" : new Date(lend.checkoutDate).getMinutes() + " AM"} on ${new Date(lend.checkoutDate).getMonth() + 1}/${new Date(lend.checkoutDate).getDate()}/${new Date(lend.checkoutDate).getFullYear()}`}</p>

                                <p>Checkin Date: {lend.checkinDate}</p>

                                <p>{lend.dueDate && `Due by ${new Date(lend.dueDate).getHours() > 12 ? new Date(lend.dueDate).getHours() - 12 : new Date(lend.dueDate).getHours()}:${new Date(lend.dueDate).getHours() > 12 ? new Date(lend.dueDate).getMinutes() + " PM" : new Date(lend.dueDate).getMinutes() + " AM"} on ${new Date(lend.dueDate).getMonth() + 1}/${new Date(lend.dueDate).getDate()}/${new Date(lend.dueDate).getFullYear()}`}</p>
                                {/* <Image fluid rounded src={sample.image} alt={sample.name}></Image> */}

                                {/* <ReactImageFallback
                                width="100%"
                                src={`/api/image/${item.image}`}
                                fallbackImage={item.image}
                                alt={sample.name} /> */}
                                {/* </Link> */}

                                <Button onClick={(e) => { VerifyCheckin(lend.checkoutId, lend.itemId) }}>
                                    Verify Return
                                </Button>
                                <Button>
                                    Message (coming soon)
                                </Button>


                            </div>
                        }
                    </div>



                ))
                }
            </div>

        </>
    );
};

export default LenderViewCheckoutList;
