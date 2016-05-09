class UsersController < ApplicationController
  before_action :doorkeeper_authorize!, only: [:show] # show のみ認証が必要

  def create
    @user = User.new(user_params)
    if @user.save
      render json: @user
    else
      head :bad_request
    end
  end

  def show
    render json: User.find(params[:id])
  end

  private

  def user_params
    params.require(:user).permit(:email, :password)
  end
end