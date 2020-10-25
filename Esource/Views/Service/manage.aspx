﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/index.Master" AutoEventWireup="true" CodeBehind="manage.aspx.cs" Inherits="Esource.Views.service.manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="manage">
        <div class="text-center">
            <a role="button" href="<%=Page.ResolveUrl("~/Views/service/add.aspx") %>" class="btn btn-md btn-rounded btn-success">
                Add Service <i class="fas fa-plus ml-2"></i>
            </a>
        </div>
        <div class="row">
            <asp:Repeater runat="server" ID="managelist" OnItemCommand="managelist_ItemCommand">
                <ItemTemplate>
                    <div class="col-12 col-md-4 col-lg-3 d-flex align-items-stretch mt-4">
                        <div class="card w-100">
                            <div class="view overlay border-bottom border-primary rounded-top">
                                <img class="card-img-top" src="" onerror="this.src='<%= Page.ResolveUrl("~/Content/img/placeholder.jpg") %>'"/>
                                <a><div class="mask rgba-black-light"></div></a>
                            </div>
                            <div class="ml-auto mr-3 mt-2">
                                 <asp:LinkButton runat="server" class="btn-danger btn-sm m-0"
                                    data-tooltip="tooltip" data-placement="top" title="Delete" CommandName="delete" CommandArgument='<%#Eval("Id") %>'>
                                    <i class="fas fa-trash-alt"></i>
                                </asp:LinkButton>

                                <asp:LinkButton runat="server" class="btn-success btn-sm m-0"
                                    data-tooltip="tooltip" data-placement="top" title="Edit" CommandName="edit" CommandArgument='<%#Eval("Id") %>'>
                                    <i class="fas fa-edit"></i>
                                </asp:LinkButton>
                                <asp:LinkButton runat="server" CssClass="btn-primary btn-sm m-0" data-tooltip="tooltip"
                                    data-placement="top" title="View More Details" CommandName="view" CommandArgument='<%#Eval("Id") %>'>
                                    <i class="fas fa-eye"></i>
                                </asp:LinkButton>
                            </div>
                            <div class="card-body d-flex flex-column">

                                <div class="d-flex mt-2">
                                    <div class="flex-fill">
                                        <img src="" onerror="this.src='<%= Page.ResolveUrl("~/Content/img/placeholder.jpg") %>'" class="rounded-circle img-fluid z-depth-1 avatar" style="max-width: 2rem;" />
                                        <asp:LinkButton runat="server" CssClass="align-middle ml-1" CommandName="viewprofile" CommandArgument='<%#Eval("uid") %>'>Username</asp:LinkButton>
                                    </div>
                                    <div class="d-flex align-items-center">
                                        <span class="text-muted small">
                                            <i class="fas fa-clock mr-2"></i><%#Eval("date_created") %>
                                        </span>
                                    </div>
                                </div>

                                <div class="d-flex mt-4">
                                    <div class="flex-fill">
                                        <h4 class="name card-title mb-0" <%--data-names="<%#Eval("name") %>"--%>><%#Eval("name") %></h4>
                                    </div>

                                    <div class="d-flex align-items-center font-weight-bold ml-3">
                                        <%--<%#Eval("views") %>--%>0<i class="far fa-eye ml-2"></i>
                                    </div>
                                </div>

                                <hr class="w-100" />
                                <div class="flex-fill">
                                    <p class="card-text">
                                        <%#Eval("desc") %>
                                    </p>
                                </div>
                                
                                <div class="d-flex">
                                    <div class="flex-fill text-right">
                                        <asp:LinkButton runat="server" CssClass="btn btn-sm btn-red mr-0" CommandName="favourite" CommandArgument='<%#Eval("Id") %>'
                                            data-tooltip="tooltip" title="Like service">
                                            <span class="font-weight-bold">
                                                <%#Eval("favs") %>
                                                <i class="fas fa-heart ml-2"></i>
                                            </span> 
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>

                            <div class="card-footer accent-2 white-text deep-purple text-center">
                                <h5 class="m-0">
                                    $<%#Eval("price") %></h5>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </section>
</asp:Content>
