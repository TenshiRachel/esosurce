<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/index.Master" AutoEventWireup="true" CodeBehind="auth.aspx.cs" Inherits="Esource.Views.jobs.auth" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="job-auth">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card z-depth-3">
                    <div class="card-body text-center">
                        <h3 class="text-center">Job/Request PIN</h3>

                        <div class="md-form md-outline">
                            <input id="jobPin" type="password" maxlength="6" class="form-control w-50" runat="server">
                            <label for="jobPin">Job PIN</label>
                        </div>

                        <asp:LinkButton ID="btnEnter" CssClass="btn btn-md btn-success btn-rounded" runat="server" OnClick="enterPIN_Click">
                            <i class="fas fa-unlock-alt mr-2"></i>Enter
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
