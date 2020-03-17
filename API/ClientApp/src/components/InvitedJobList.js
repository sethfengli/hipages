import React, { Component } from 'react';
import Moment from 'react-moment';
import './JobCard.css';
import 'font-awesome/css/font-awesome.min.css';

export class InvitedJobList extends Component {
    static displayName = InvitedJobList.name;

    constructor(props) {
        super(props);
        this.state = { invitedJobs: [], loading: true };
    }

    componentDidMount() {
        this.populateInvitedJobs();
    }

    static renderJobCards(invitedJobs) {
        const onBtnClick =(e) => {
            e.stopPropagation();
            let id = e.target.parentNode.id;
            let status = e.target.className === "accept" ? "accepted" : "declined";
            let jsonBody = JSON.stringify({
                                "id": Number(id),
                                "status": status
                            });
            e.target.parentNode.style.display = "none";
            fetch(`api/JobList/${id}`, {
                method: 'PUT',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                },
                body: jsonBody
            });
        }

        let formatter = new Intl.NumberFormat('en-US', {
            style: 'currency',
            currency: 'USD',
        });

        return (
        <React.Fragment>
        {invitedJobs.map(invitedJob =>
            <div key={invitedJob.id} id={invitedJob.id} className="job-card">
                <div className="name-and-time">
                    <div className="first-initial-letter">
                        {invitedJob.contactName.charAt(0)}
                    </div>
                    <div className="name-create-time">
                        <div className="firstname">{invitedJob.contactName.replace(/ .*/, '')}</div>  
                        <div className="create-time"> <Moment format="MMMM DD @ h:mm a">
                                                        {invitedJob.createdAt}
                                                    </Moment></div> 
                    </div>
                </div>
                <div className="suburb-and-category">
                    <i className="fa fa-map-marker font-icon" aria-hidden="true" ></i>
                    {invitedJob.suburb.name} &nbsp;
                    {invitedJob.suburb.postCode}
                    <i className="fa fa-briefcase font-icon" aria-hidden="true"></i>
                    {invitedJob.category.name} &nbsp; &nbsp;
                    JobID:{invitedJob.id}
                </div>
                <div className="description">
                    <p>{invitedJob.description}</p>
                </div>             
                <button onClick={onBtnClick} className="accept">
                    Accept
                </button>
                <button onClick={onBtnClick} className="decline">
                    Decline 
                </button> &nbsp;
                <span className="lead-price">{formatter.format(invitedJob.price)}</span>&nbsp;
                Lead Inviation
            </div>        
        )}
        </React.Fragment>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : InvitedJobList.renderJobCards(this.state.invitedJobs);

        return (  <React.Fragment>{contents} </React.Fragment> );
    }

    async populateInvitedJobs() {
        const response = await fetch('api/JobList/new');
        const data = await response.json();
        this.setState({ invitedJobs: data, loading: false });
    }
}
