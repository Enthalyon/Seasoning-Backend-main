﻿using MediatR;
using SeasoningAndCandle.Backend.Application.ViewModels;

namespace SeasoningAndCandle.Backend.Application.Queries
{
    public class GetCategoriesQuery : IRequest<CategoryViewModel>
    {

    }
}